using FreeChat.Core.Models;
using FreeChat.Core.Models.Enums.ChatEngineEnums;
using FreeChat.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChat.Web.Hubs
{
    [Authorize]
    public class Chat : Hub
    {
        //Dictionary gia tous online users
        private static readonly ConcurrentDictionary<string, string> CoUsers =
            new ConcurrentDictionary<string, string>();


        //Dictionary for the connected users in each room ex(roomName:Username)
        private static readonly ConcurrentDictionary<string, List<string>> RoomsUsers =
            new ConcurrentDictionary<string, List<string>>();


        //Dictionary for caching the last 50 messages of each room

        private static readonly ConcurrentDictionary<string, List<MessageDetail>> MessageCaching =
            new ConcurrentDictionary<string, List<MessageDetail>>();

        private static readonly ConnectionMapping<string> Connections =
            new ConnectionMapping<string>();



        //private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        //private readonly Timer _timer;
        //

        // (1) Send the Callers Client Username to the view 
        public void SendUsername()
        {
            var name = Context.User.Identity.Name;
            Clients.Caller.SendName(name);

        }
        //(2) Send Messages to room and cashing <=50 messages for this room
        public void SendMessageToRoom(string room, string message)
        {
            var date = DateTime.Now;
            var messageSend = new List<string> { Context.User.Identity.Name, message, date.ToString(CultureInfo.InvariantCulture) };


            Clients.Group(room).newMessage(messageSend);


            if ((MessageCaching.TryGetValue(room, out var existingMessageCashing)) &&
                (existingMessageCashing.Count <= 50))
            {

                existingMessageCashing.Add(new MessageDetail
                {
                    Message = message,
                    UserName = Context.User.Identity.Name,
                    TimeSend = date.ToString(CultureInfo.InvariantCulture)
                });
            }

            messageSend.Clear();
        }

        //(3)Send Message to Specific user inside the room
        public void SendMessageToUser(string nameToChat, string message, string group2Name)
        {
            var date = DateTime.Now;
            var user = RoomsUsers
                .FirstOrDefault(x => x.Value.Contains(nameToChat))
                .Key;
            var messageSend = new List<string> { Context.User.Identity.Name, message, date.ToString(CultureInfo.InvariantCulture) };

            Clients.User(user).newMessage(messageSend);
        }


        //(4) add this user in the room
        //add this users to the dictionary RoomUsers in format room,name



        public void JoinRoom(string room)
        {

            //create a variable for the out of tryGetvalue
            //if room exist just add the name in the list of the room

            // InformActiveField(room);

            if (RoomsUsers.TryGetValue(room, out var existing))
            {

                if (!existing.Exists(item => item == Context.User.Identity.Name))
                {

                    existing.Add(Context.User.Identity.Name);
                    RoomsUsers[room] = existing;
                }


            }
            //if the room doesnt exist in the dictionary 
            //add it and then add the username in the list of the roomName
            //also create a messageCashing for that room
            else
            {
                RoomsUsers.TryAdd(room, new List<string>());
                RoomsUsers[room].Add(Context.User.Identity.Name);
                MessageCaching.TryAdd(room, new List<MessageDetail>());

            }


            Groups.Add(Context.ConnectionId, room);
        }

        //(5)Remove the user from the group also remove the user from the dictionary RoomUsers
        public void LeaveRoom(string room)
        {

            //remove this user from the room
            //inform the others that this users left the room
            if (RoomsUsers.TryGetValue(room, out var existing))
            {
                existing.Remove(Context.User.Identity.Name);
                RoomsUsers[room] = existing;
            }

            if (existing == null)
            {
                RoomsUsers.TryRemove(room, out existing);

            }


            Groups.Remove(Context.ConnectionId, room);


        }

        //(6) Get and Return the connected Users from the CoUsers Dictionary 

        public IEnumerable<string> GetConnectedUsers()
        {
            return CoUsers.Values.ToArray();
        }

        //(7) Get and Return the connected users inside the RoomUsers Dictionary
        public IEnumerable<string> GetConnectedRoomUsers(string room)
        {
            var existing = RoomsUsers[room];

            return existing;
        }

        //(8) Use the return value of GetConnectedUsers method and send it back to the client
        public void SendConnectedUsers()
        {
            Clients.All.onlineUsers(GetConnectedUsers());
        }


        //(9)Use the return value of GetRoomConnectedUsers method and send it back to the client
        public void SendRoomConnectedUsers(string room, OnlineUsersSituationEnum situation)
        {
            var connectedUsers = GetConnectedRoomUsers(room);
            switch (situation)
            {
                case OnlineUsersSituationEnum.InitialSeeding:
                    Clients.Group(room).onlineUsers(connectedUsers);
                    break;
                case OnlineUsersSituationEnum.UpdateOnlineUsers:
                    Clients.Group(room).onlineUsersUpdate(connectedUsers);
                    break;
                case OnlineUsersSituationEnum.Confirmation:
                    Clients.Group(room).onlineUsersUpdate(connectedUsers);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(situation), situation, null);
            }

        }


        //(10)Add User Connectionid and attach it with its username
        public override Task OnConnected()
        {
            var eventDe = 0;

            var name = Context.User.Identity.Name;
            Connections.Add(name, Context.ConnectionId);

            if (CoUsers.TryAdd(Context.ConnectionId, Context.User.Identity.Name))
            {
                UpdateIndex();
                SendMonitorData("Connected..users added...", Context.ConnectionId);
            }
            eventDe = 1;
            // InformActiveField(eventDe);
            return base.OnConnected();

        }

        //(11) Remove user from the CoUsers Dictionary 
        public override Task OnDisconnected(bool stopCalled)
        {


            var eventDe = 0;

            var name = Context.User.Identity.Name;
            Connections.Remove(name, Context.ConnectionId);
            //foreach (var item in CoUsers.Where(kvp => kvp.Value == name).ToList())
            // {
            // }

            if (CoUsers.TryRemove(Context.ConnectionId, out name))
            {

                UpdateIndex();
                SendMonitorData("Disconnected..also user removed", Context.ConnectionId);
            }
            eventDe = 2;
            //InformActiveField(eventDe);
            return base.OnDisconnected(stopCalled);

        }

        public override Task OnReconnected()
        {



            var name = Context.User.Identity.Name;
            if (!Connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                Connections.Add(name, Context.ConnectionId);
            }

            UpdateIndex();
            SendMonitorData("Reconnected", Context.ConnectionId);
            //InformActiveField();
            return base.OnReconnected();
        }

        private void UpdateIndex()
        {

            var onlineusers = CoUsers.Count();
            var roomsActive = RoomsUsers.Count();
            var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            context.Clients.All.updateOnlineUsersInRooms(onlineusers, roomsActive);


        }

        public void SendMonitorData(string eventType, string connectionId)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            context.Clients.All.newEvent(eventType, connectionId);
            //context.Clients.All.updateActive();
        }

        //(12)
        //Send cashed messages for the room that caller joined 
        public void SendSavedRoomMessages(string room)
        {
            MessageCaching.TryGetValue(room, out var existingMessageCashing);

            if (existingMessageCashing != null) Clients.Caller.loadHistory(existingMessageCashing.ToArray());
        }


        //(13)Create a group with the name of the person that the caller wants to communicate
        public void PrivateChat(string nameToChat)
        {
            var user = RoomsUsers
                .FirstOrDefault(x => x.Value.Contains(nameToChat))
                .Key;

            //Creating a group with groupName equals with the desired client to chat(nameToChat)
            //then add currentuser and nametochat to the group
            Groups.Add(user, nameToChat);
            Groups.Add(Context.ConnectionId, nameToChat);
        }


        /*public void InformActiveField(int value)
        {
            int usersCount = 0;
            var context1 = new FreeChatContext();

            foreach (var items in RoomsUsers)
            {

                //count the users inside the connected users list for each room
                usersCount = (items.Value).Count();

                //music rooms
                var result = (from a in context1.Music
                              where a.TopicName.Equals(items.Key)
                              select a).SingleOrDefault();




                try
                {

                    if ((result != null))
                    {
                        //onConnected
                        if (value == 1)
                        {
                            result.Active = true;
                            ++result.UserPerDay;
                        }
                        //ondisconnected
                        else if (value == 2)
                        {
                            result.Active = false;
                            if (result.UserPerDay > 0)
                                --result.UserPerDay;
                        }
                    }
                }
                catch (Exception)
                {

                }


                //sports rooms
                var result2 = (from a in context1.Sports
                               where a.TopicName.Equals(items.Key)
                               select a).SingleOrDefault();
                try
                {

                    if ((result2 != null))
                    {
                        if (value == 1)
                        {
                            result2.Active = true;
                            ++result2.UserPerDay;
                        }
                        //ondisconnected
                        else if (value == 2)
                        {
                            result2.Active = false;
                            if (result2.UserPerDay > 0)
                                --result2.UserPerDay;
                        }
                    }


                }
                catch (Exception)
                {

                }

                //trips rooms
                var result3 = (from a in context1.Trips
                               where a.TopicName.Equals(items.Key)
                               select a).SingleOrDefault();
                try
                {

                    if ((result3 != null))
                    {
                        if (value == 1)
                        {
                            result3.Active = true;
                            ++result3.UserPerDay;
                        }
                        //ondisconnected
                        else if (value == 2)
                        {
                            result3.Active = false;
                            if (result3.UserPerDay > 0)
                                --result3.UserPerDay;
                        }
                    }


                }
                catch (Exception)
                {

                }

                context1.SaveChanges();
                //if at least one of the linq queries result are not empty meaning that the roomname have been found make the active field true

            }*/




    }
}
