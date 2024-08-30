using System;

public struct TimeState
{
    public int minutes, seconds;
    public TimeState(long mins, long secs)
    {
        minutes = (int)mins;
        seconds = (int)secs;
    }
}
public static class TimeManager
{
    static long start_time;
    static long time_skipped;
    static long stop_time;
    static long time()
    {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }
    public static void Init()
    {
        start_time = time();
        time_skipped = 0;
    }
    public static void Stop()
    {
        stop_time = time();
    }
    public static void Continue()
    {
        time_skipped+= time()-stop_time;
    }
    public static TimeState Get()
    {
        long time_elapsed=time()-time_skipped-start_time;
        time_elapsed /= 1000;
        return new TimeState(time_elapsed/60,time_elapsed%60);
    }
}
