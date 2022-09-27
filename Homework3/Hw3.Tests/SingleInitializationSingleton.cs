using System;
using System.Threading;

namespace Hw3.Tests;

public class SingleInitializationSingleton
{
    private static readonly object Locker = new();

    private static volatile bool _isInitialized = false;

    public const int DefaultDelay = 3_000;
    
    public int Delay { get; }

    private SingleInitializationSingleton(int delay = DefaultDelay)
    {
        Delay = delay;
        // imitation of complex initialization logic
        Thread.Sleep(delay);
    }

    internal static void Reset()
    {
        Instance = new SingleInitializationSingleton();
        _isInitialized = false;
    }

    public static void Initialize(int delay)
    {
        if (!_isInitialized)
        {
            lock (Locker)
            {
                if (!_isInitialized)
                {
                    Instance = new SingleInitializationSingleton(delay);
                    _isInitialized = true;
                }
                else
                    throw new InvalidOperationException();
            }
        }
        else
            throw new InvalidOperationException();
    }

    public static SingleInitializationSingleton Instance => new ;

}