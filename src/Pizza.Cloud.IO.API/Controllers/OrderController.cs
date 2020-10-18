using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pizza.Cloud.IO.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : TwilioController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public OrderController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("Incoming/{phoneNumber}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "VoiceResponse successfully returned", Type = typeof(VoiceResponse))]
        public async Task<ActionResult<VoiceResponse>> Incoming(string phoneNumber)
        {
            var response = new VoiceResponse();

            var order = await _unitOfWork.Orders.GetOrderWithPizzasByPhoneNumberAsync(phoneNumber);

            if (order == null)
            {
                response.Say("Pizza Cloudio bonjour!", language: Twilio.TwiML.Voice.Say.LanguageEnum.FrFr);
            }
            else
            {
                response.Say("Pizza Cloudio re-bonjour!", language: Twilio.TwiML.Voice.Say.LanguageEnum.FrFr);
            }

            response.Redirect(new Uri($"{_configuration.GetSection("Twilio:WebhookUrlPath").Value}v1/Accounts/{_configuration.GetSection("Twilio:AccountSid").Value}/flows/{_configuration.GetSection("Twilio:FlowId").Value}?FlowEvent=return"));

            return new ContentResult{
                ContentType = "text/xml",
                Content = response.ToString(),
                StatusCode = 200
            };
        }
    }
}
