﻿using System.Globalization;

namespace Portfolio
{
    public class Portfolio
    {
        private readonly string _portfolioCsvPath;

        public Portfolio(string portfolioCsvPath)
        {
            _portfolioCsvPath = portfolioCsvPath;
        }

        public void ComputePortfolioValue()
        {
            var now = GetNow();
            var lines = ReadAssetsFileLines();
            var portfolioValue = new MeasurableValue(0);

            foreach (var line in lines)
            {
                var columns = line.Split(",");
                var provider = new CultureInfo("fr-FR");
                var dateAsString = columns[1];
                var dateTime = CreateAssetDateTime(dateAsString, provider);
                var asset = new Asset(columns[0],
                    dateTime,
                    columns[0] == "Unicorn" ? new PricelessValue() : new MeasurableValue(float.Parse(columns[2])));

                if (asset.Date.Subtract(now).TotalDays < 0)
                {
                    if (asset.Description != "French Wine")
                    {
                        if (asset.Description != "Lottery Prediction")
                        {
                            if (asset.Value.Get() > 0)
                            {
                                if (asset.Description != "Unicorn")
                                {
                                    asset.Value = new MeasurableValue(asset.Value.Get() - 20);
                                }
                                else
                                {
                                    DisplayMessage("Portfolio is priceless because it got a unicorn on " +
                                                   FormatDate(asset.Date, provider) + "!!!!!");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            asset.Value = new MeasurableValue(asset.Value.Get() - asset.Value.Get());
                        }
                    }
                    else
                    {
                        if (asset.Value.Get() < 200)
                        {
                            asset.Value = new MeasurableValue(asset.Value.Get() + 20);
                        }
                    }
                }
                else
                {
                    if (asset.Description != "French Wine" && asset.Description != "Lottery Prediction")
                    {
                        if (asset.Value.Get() > 0.0)
                        {
                            if (asset.Description != "Unicorn")
                            {
                                asset.Value = new MeasurableValue(asset.Value.Get() - 10);
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Portfolio is priceless because it got a unicorn on " +
                                    FormatDate(asset.Date, provider) + "!!!!!");
                                return;
                            }
                        }
                        else
                        {
                            if (asset.Description == "Unicorn")
                            {
                                Console.WriteLine(
                                    "Portfolio is priceless because it got a unicorn on " +
                                    FormatDate(asset.Date, provider) + "!!!!!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (asset.Description == "Lottery Prediction")
                        {
                            if (asset.Value.Get() < 800)
                            {
                                asset.Value = new MeasurableValue(asset.Value.Get() + 5);

                                if (asset.Date.Subtract(now).TotalDays < 11)
                                {
                                    if (asset.Value.Get() < 800)
                                    {
                                        asset.Value = new MeasurableValue(asset.Value.Get() + 20);
                                    }
                                }

                                if (asset.Date.Subtract(now).TotalDays < 6)
                                {
                                    if (asset.Value.Get() < 800)
                                    {
                                        asset.Value = new MeasurableValue(asset.Value.Get() + 100);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (asset.Value.Get() < 200)
                            {
                                asset.Value = new MeasurableValue(asset.Value.Get() + 10);
                            }
                        }
                    }
                }

                portfolioValue = new MeasurableValue(portfolioValue.Get() + asset.Value.Get());
            }

            Console.WriteLine(portfolioValue);
        }

        protected virtual DateTime GetNow()
        {
            return DateTime.Now;
        }

        protected virtual string[] ReadAssetsFileLines()
        {
            string readText = File.ReadAllText(_portfolioCsvPath);
            var lines = readText.Split(Environment.NewLine);
            return lines;
        }

        protected virtual void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        protected virtual string FormatDate(DateTime assetDate, CultureInfo provider)
        {
            return assetDate.ToString(provider);
        }

        protected virtual DateTime CreateAssetDateTime(string dateAsString, CultureInfo cultureInfo)
        {
            return DateTime.Parse(dateAsString, cultureInfo);
        }
    }
}