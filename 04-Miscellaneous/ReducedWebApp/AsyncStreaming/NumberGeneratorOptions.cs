﻿using Light.GuardClauses;

namespace ReducedWebApp.AsyncStreaming;

public sealed record NumberGeneratorOptions
{
    private readonly int _amountOfNumbers = 20;

    public required int AmountOfNumbers
    {
        get => _amountOfNumbers;
        init => _amountOfNumbers = value.MustBeGreaterThan(0);
    }
}