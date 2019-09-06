from django.shortcuts import render, redirect, HttpResponse
from .models import Author,Book
# Create your views here.
def index(request):
    context = {
        "books" : Book.objects.all()
    }
    return render(request, 'books_authors_app/add_book.html',context)

def add_book(request):
    Book.objects.create(title=request.POST['title'],desc=request.POST['desc'])
    return redirect('/')

def book_info(request,num):
    context = {
        "book" : Book.objects.get(id=int(num)),
        'authors': Author.objects.all()
    }
    return render(request,'books_authors_app/book_info.html',context)

def add_author_to_book(request):
    book_id = int(request.POST['book_id'])
    author_id = int(request.POST['author_id'])
    book = Book.objects.get(id=book_id)
    author = Author.objects.get(id=author_id)
    if author not in book.authors.all():
        book.authors.add(author)
    return redirect(f'/books/{book_id}')

def authors(request):
    context = {
        'authors': Author.objects.all()
    }
    return render(request,'books_authors_app/add_author.html',context)

def add_author(request):
    Author.objects.create(first_name=request.POST['first_name'],last_name=request.POST['last_name'],notes=request.POST['notes'])
    return redirect('/authors')

def author_info(request,num):
    context = {
        "author" : Author.objects.get(id=int(num)),
        'books': Book.objects.all()
    }
    return render(request,'books_authors_app/author_info.html',context)

def add_book_to_author(request):
    book_id = int(request.POST['book_id'])
    author_id = int(request.POST['author_id'])
    book = Book.objects.get(id=book_id)
    author = Author.objects.get(id=author_id)
    if book not in author.books.all():
        author.books.add(book)
    return redirect(f'/authors/{author_id}')