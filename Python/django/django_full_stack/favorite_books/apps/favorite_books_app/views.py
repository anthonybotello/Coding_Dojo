from django.shortcuts import render, redirect, reverse, HttpResponse
from .models import Book
from apps.login.models import User
from django.contrib import messages

# Create your views here.
def home(request):
    user = User.objects.get(id=int(request.session['user_id']))
    context = {
        'first_name': user.first_name,
        'user_id': user.id,
        'liked_books': user.liked_books.all(),
        'books': Book.objects.all()
    }
    return render(request,'favorite_books_app/home.html',context)

def add_book(request):
    errors = Book.objects.book_validator(request.POST)
    if len(errors) > 0:
        for key,value in errors.items():
            messages.error(request,value)
        return redirect(reverse('books:home'))
    else:
        user=User.objects.get(id=int(request.session['user_id']))
        Book.objects.create(
            title=request.POST['title'],
            desc=request.POST['desc'],
            uploaded_by=user,
        )
        user.liked_books.add(Book.objects.last())
        return redirect(reverse('books:home'))

def book_info(request,book_id):
    user = User.objects.get(id=int(request.session['user_id']))
    context = {
        'first_name': user.first_name,
        'user_id': user.id,
        'liked_books': user.liked_books.all(),
        'book': Book.objects.get(id=int(book_id)),
    }
    return render(request,'favorite_books_app/book_info.html',context)

def like_unlike(request,book_id):
    user = User.objects.get(id=int(request.session['user_id']))
    book = Book.objects.get(id=int(book_id))
    book_id = book.id
    print(request.POST)
    if request.POST['like'] == 'unlike':
        user.liked_books.remove(book)
        return redirect(reverse('books:home'))
    elif request.POST['like'] == 'like':
        user.liked_books.add(book)
        return redirect(reverse('books:book_info', kwargs={'book_id':book_id}))

def delete_book(request,book_id):
    Book.objects.get(id=int(book_id)).delete()
    return redirect(reverse('books:home'))

def update_book(request):
    book_id = int(request.POST['book_id'])
    book = Book.objects.get(id=book_id)
    book.title = request.POST['title']
    book.desc = request.POST['desc']
    book.save()
    return redirect(reverse('books:book_info',kwargs={'book_id':book_id}))

def user_favorites(request,user_id):
    user_id = int(user_id)
    context = {
        'first_name': User.objects.get(id=user_id).first_name,
        'books': User.objects.get(id=user_id).liked_books.all()
    }
    return render(request,'favorite_books_app/user_favorites.html',context)