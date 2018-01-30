using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace FreeChat.Services
{
    public sealed class NewtonJsonResult : ActionResult
    {
        public object Data { get; set; }
        public string ContentType { get; set; }
        public Formatting Formatting { get; set; }
        public Encoding ContentEncoding { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public JsonSerializerSettings SerializerSettings { get; set; }


        // ReSharper disable once UnusedMember.Local
        private NewtonJsonResult()
            : this(HttpStatusCode.OK)
        {
        }

        public NewtonJsonResult(object data = null)
            : this(HttpStatusCode.OK, data)
        {
        }

        public NewtonJsonResult(HttpStatusCode statusCode = HttpStatusCode.OK, object data = null)
        {
            Data = data;
            StatusCode = statusCode;
            SerializerSettings = DefaultJsonSerializerSettings;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;
            response.StatusCode = (int)StatusCode;
            response.ContentType = "application/json"; //order
            response.ContentEncoding = ContentEncoding ?? response.ContentEncoding; //order
            if (Data == null) return; //order

            using (var writer = new JsonTextWriter(response.Output) { Formatting = Formatting })
            {
                JsonSerializer.Create(SerializerSettings).Serialize(writer, Data);
                writer.Flush();
            }
        }

        public static NewtonJsonResult OK(object data = null) => new NewtonJsonResult(HttpStatusCode.OK, data ?? "");
        public static NewtonJsonResult Bad(object data = null) => new NewtonJsonResult(HttpStatusCode.BadRequest, data ?? "");
        public static NewtonJsonResult NotFound(object data = null) => new NewtonJsonResult(HttpStatusCode.NotFound, data ?? "");
        public static NewtonJsonResult Forbidden(object data = null) => new NewtonJsonResult(HttpStatusCode.Forbidden, data ?? "");
        public static NewtonJsonResult NotAcceptable(object data = null) => new NewtonJsonResult(HttpStatusCode.NotAcceptable, data ?? "");
        public static NewtonJsonResult InternalServerError(object data = null) => new NewtonJsonResult(HttpStatusCode.InternalServerError, data ?? "");

        private static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings();
    }
}