﻿namespace Ecommerce_WatchShop.Abstractions
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}
