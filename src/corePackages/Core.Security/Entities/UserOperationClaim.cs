﻿using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserOperationClaim : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public User User { get; set; }  
        public OperationClaim   OperationClaim { get; set; }
    }
}
