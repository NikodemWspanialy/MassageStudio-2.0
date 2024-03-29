﻿using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Commands.ReserveTerm
{
    internal class ReserveTermCommandHandler : IRequestHandler<ReserveTermCommand, IdentityResult>
    {
        private readonly IMassageTermRepository repository;
        private readonly IMassageTypeRepository typeRepository;
        private readonly IUserContext userContext;

        public ReserveTermCommandHandler(IMassageTermRepository termRepository,IMassageTypeRepository typeRepository,  IUserContext userContext)
        {
            this.repository = termRepository;
            this.typeRepository = typeRepository;
            this.userContext = userContext;
        }
        public async Task<IdentityResult> Handle(ReserveTermCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null)
            {
                var massage = await repository.GetMassageByIsAsync(request.Id);
                if (massage != null && massage.Free)
                {
                    var type = await typeRepository.GetTypeByNameAsync(request.Type);
                    if (type == null)
                    {
                        return IdentityResult.Failed();
                    }
                    massage.TypeName = type.Name;
                    massage.Free = false;
                    massage.ClientId = currentUser.Id;
                    massage.ClientName = currentUser.Name;
                    massage.ClientLastName = currentUser.LastName;

                    await repository.SaveChangesAsync();
                    return IdentityResult.Success;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            throw new Exception("Nor permission");
        }
    }
}

