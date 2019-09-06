from django.shortcuts import render, redirect
from .models import Order, Product

def index(request):
    context = {
        "all_products": Product.objects.all()
    }
    return render(request, "store/index.html", context)

def process_order(request):
    quantity_from_form = int(request.POST["quantity"])
    price_from_form = float(Product.objects.get(id=request.POST['product_id']).price)
    total_charge = quantity_from_form * price_from_form
    Order.objects.create(quantity_ordered=quantity_from_form, total_price=total_charge)
    print("Charging credit card...")
    return redirect('/checkout')

def checkout(request):
    context = {
        'total': Order.objects.last().total_price,
        'qty_all': 0,
        'total_all': 0
        }
    for order in Order.objects.all():
            context['qty_all'] += order.quantity_ordered
            context['total_all'] += order.total_price
    return render(request, "store/checkout.html",context)