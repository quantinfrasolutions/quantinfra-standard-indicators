using QuantInfra.Sdk.MarketData.Abstractions;

namespace QuantInfra.StandardIndicators
{
    public class PriceTransformer : AbstractIndicator
    {
        AbstractIndicator _underlyingIndicator;

        public PriceTransformer(AbstractIndicator basePrice = null, CandleType priceType = CandleType.Candle)
        {
            basePrice = basePrice ?? new Close();

            switch (priceType)
            {
                case CandleType.Log:
                    _underlyingIndicator = new Log(basePrice);
                    break;
                case CandleType.Candle:
                    _underlyingIndicator = basePrice;
                    break;
                case CandleType.HeikenClose:
                    _underlyingIndicator = new HeikinAshiClose();
                    break;
                case CandleType.HeikenOpen:
                    _underlyingIndicator = new HeikinAshiOpen();
                    break;
                case CandleType.HeikenLow:
                    _underlyingIndicator = new HeikinAshiLow();
                    break;
                case CandleType.HeikenHigh:
                    _underlyingIndicator = new HeikinAshiHigh();
                    break;
                default:
                    _underlyingIndicator = basePrice;
                    break;
            }
            RegisterIndicator(_underlyingIndicator);

            Id = $"PriceTransformer:{priceType}({basePrice.Id})";
        }


        protected override double? Calculate(IBarStorage bars, double? price = null)
        {
            return _underlyingIndicator.GetValue(bars[0]);
        }
    }
}