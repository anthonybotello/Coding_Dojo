from django.shortcuts import render, redirect, reverse
from .models import Stock
from alpha_vantage.timeseries import TimeSeries
# Create your views here.

ts = TimeSeries(key='12J0CJ1HBE0F8CYV')
def index(request):
    return render(request,'in_stock_app/index.html')

def dashboard(request):
    return render(request,'in_stock_app/dashboard.html')

def browse(request):
    context={
        'stocks': {}
    }
    for stock in Stock.objects.all():
        context['stocks'][stock.symbol] = ts.get_quote_endpoint(stock.symbol)
    print(context)
    return render(request,'in_stock_app/browse.html',context)

def stock_info(request,symbol):
    context={
        'stock':Stock.objects.get(symbol__iexact=symbol)
    }
    return render(request,'in_stock_app/info.html',context)

def portfolio(request):
    return render(request,'in_stock_app/portfolio.html')