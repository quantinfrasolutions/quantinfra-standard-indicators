using QuantInfra.Sdk.MarketData.Abstractions;

namespace QuantInfra.StandardIndicators;

public class BaseAverage : AbstractIndicator
{
    AbstractIndicator _underlyingIndicator;
    int _period;
     
    public BaseAverage(AbstractIndicator basePrice, int period = 9, AverageType maType = AverageType.SMA,
        int phase = 50, int power = 2)
    {
        basePrice = basePrice ?? new Close();
        _period = period;

        switch (maType)
        {
            case AverageType.CorrectedAverage:
                _underlyingIndicator = new CorrectedAverage(basePrice, period);
                break;
            case AverageType.EMA:
                _underlyingIndicator = new EMA(basePrice, period);
                break;
            case AverageType.SMA:
                _underlyingIndicator = new SimpleMovingAverage(basePrice, period);
                break;
            case AverageType.HMA:
                _underlyingIndicator = new HMA(basePrice, period);
                break;
            case AverageType.WMA:
                _underlyingIndicator = new WMA(basePrice, period);
                break;
            case AverageType.JMA:
                _underlyingIndicator = new JMA(basePrice, period, phase, power);
                break;
            case AverageType.SuperSmoother:
                _underlyingIndicator = new SuperSmoother(basePrice, period);
                break;
            default:
                _underlyingIndicator = new SimpleMovingAverage(basePrice, period);
                break;
        }

        RegisterIndicator(_underlyingIndicator);

        Id = $"BaseAverage:{_period}:{maType}({basePrice.Id})";
    }


    protected override double? Calculate(IBarStorage bars, double? price = null)
    {
        return _underlyingIndicator.GetValue(bars[0]);
    }
}