using Autofac;
using CardsGameServer.ApplicationLayer.Registration.Containers;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CardsGameServer.ApplicationLayer.Validation
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        private readonly ValidatorFactory validatorFactory;
        private readonly RegistrationValidators registrationAppServices;

        public ValidateModelStateFilter()
        {
            this.registrationAppServices = new RegistrationValidators();
            this.validatorFactory = new ValidatorFactory();
        }

        private ValidationResult Validate(HttpActionContext actionContext)
        {
            Collection<HttpParameterDescriptor> parameters = actionContext.ActionDescriptor.GetParameters();
            HttpParameterDescriptor parameter = parameters == null ? null : parameters.FirstOrDefault();

            string parameterName = parameter.ParameterName;
            Type parameterType = parameter.ParameterType;

            object parameterValue = actionContext.ActionArguments == null && !actionContext.ActionArguments.Any() ?
                                                null :
                                                actionContext.ActionArguments.First().Value;

            return this.validatorFactory.CreateInstance(parameterName).Validate(parameterValue);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ValidationResult validationResult = this.Validate(actionContext);

            if (validationResult.Errors.Any())
            {
                IEnumerable<string> errorMessages = validationResult.Errors.Where(err => !string.IsNullOrWhiteSpace(err.ErrorMessage))
                                                                           .Select(e => e.ErrorMessage);
                string messages = String.Join(",", errorMessages);

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, messages);
            }
        }
    }
}
