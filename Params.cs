using System;

namespace QuantInfra.StandardIndicators;

public enum CandleType
{
    Candle,
    Log,
    HeikenClose,
    HeikenOpen,
    HeikenLow,
    HeikenHigh
}

public enum AverageType
{
    SuperSmoother,
    SMA,
    EMA,
    CorrectedAverage,
    JMA,
    HMA,
    WMA      
}

[Flags]
public enum StrategyDirectionType
{
    LongShort = 3,
    Short = 2,
    Long = 1,
}

public enum MoneyManagegmentType
{
    FixMoneyManagement,
    AtrMoneyManagement
}