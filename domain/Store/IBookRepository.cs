﻿namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);

    }
}
