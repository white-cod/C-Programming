using System;
using System.Threading;

class Philosophy
{
    private static Mutex[] forks = new Mutex[5];
    private static Mutex eatingMutex = new Mutex();

    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            forks[i] = new Mutex();
        }

        Thread[] philosophers = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            philosophers[i] = new Thread(PhilosopherThread);
            philosophers[i].Start(i);
        }

        for (int i = 0; i < 5; i++)
        {
            philosophers[i].Join();
        }
    }

    static void PhilosopherThread(object philosopherNumber)
    {
        int philosopherIndex = (int)philosopherNumber;

        while (true)
        {
            Think(philosopherIndex);

            eatingMutex.WaitOne();
            int leftForkIndex = philosopherIndex;
            int rightForkIndex = (philosopherIndex + 1) % 5;
            eatingMutex.ReleaseMutex();

            if (leftForkIndex < rightForkIndex)
            {
                forks[leftForkIndex].WaitOne();
                forks[rightForkIndex].WaitOne();
            }
            else
            {
                forks[rightForkIndex].WaitOne();
                forks[leftForkIndex].WaitOne();
            }

            Eat(philosopherIndex);

            forks[leftForkIndex].ReleaseMutex();
            forks[rightForkIndex].ReleaseMutex();
        }
    }

    static void Think(int philosopherIndex)
    {
        Console.WriteLine($"Философ {philosopherIndex + 1} думает.");
        Thread.Sleep(1000);
    }

    static void Eat(int philosopherIndex)
    {
        Console.WriteLine($"Философ {philosopherIndex + 1} ест.");
        Thread.Sleep(1000);
    }
}