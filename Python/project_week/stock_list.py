from alpha_vantage.timeseries import TimeSeries
ts = TimeSeries(key='12J0CJ1HBE0F8CYV')
data,meta_data=ts.get_quote_endpoint('MSFT')
print(data)