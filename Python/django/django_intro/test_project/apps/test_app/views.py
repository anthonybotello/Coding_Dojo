from django.shortcuts import render, HttpResponse
from .models import Author, Book

# Create your views here.
def index(request):
    context = {
       "authors": Author.objects.all()
    } 
    return render(request,"test_app/index.html",context)