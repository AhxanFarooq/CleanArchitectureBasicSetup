using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Command.UpdateUser
{
    public class UpdateUserUserValidator:AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserUserValidator() {
        }
    }
}
