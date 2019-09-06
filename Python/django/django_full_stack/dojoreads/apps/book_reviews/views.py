from django.shortcuts import render, redirect, reverse, HttpResponse
from .models import Author, Book, Review
from apps.login.models import User
from django.contrib import messages

# Create your views here.
def home(request):
    user = User.objects.get(id=int(request.session['user_id']))
    context = {
        'first_name': user.first_name,
        'user_id': user.id,
        'books': Book.objects.all()
    }
    return render(request,'book_reviews/home.html',context)

def add(request):
    if 'logged_in' in request.session:
        user = User.objects.get(id=int(request.session['user_id']))
        context = {
            'first_name': user.first_name,
            'user_id': user.id,
            'books': Book.objects.all()
        }
        return render(request,'book_reviews/add.html',context)
    else:
        return redirect(reverse('reg_login:home'))

def add_book(request):
    errors = Book.objects.book_validator(request.POST)
    if len(errors) > 0:
        for key,value in errors.items():
            messages.error(request,value)
        return redirect(reverse('books:home'))
    elif 'new_book' in request.POST:
        user=User.objects.get(id=int(request.session['user_id']))
        Book.objects.create(
            title=request.POST['title'],
            desc=request.POST['desc']
        )
        if request.POST['rating'] != None:

            Review.objects.create(
                review=request.POST['review'],
                rating=request.POST['rating'],
                book_reviewed=Book.objects.last(),
                reviewer=user,
                )
        return redirect(reverse('books:home'))

def book_info(request,book_id):
    user = User.objects.get(id=int(request.session['user_id']))
    context = {
        'first_name': user.first_name,
        'user_id': user.id,
        'book': Book.objects.get(id=int(book_id)),
    }
    return render(request,'book_reviews/book_info.html',context)
