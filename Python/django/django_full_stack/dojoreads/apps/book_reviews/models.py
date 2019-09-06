from django.db import models
from apps.login.models import User
import re

# Create your models here.
class FormManager(models.Manager):
    def book_validator(self,postData):
        errors = {}
        if not postData['title']:
            errors['title'] = "Title is required."
        if len(postData['desc']) < 5:
            errors['desc'] = "Description must be at least 5 characters"

        name_pattern = re.compile(r'^[A-Za-z-. ]+$')
        if not postData['author']:
            errors['author'] = "Author is required."
        else:
            if len(postData['author']) < 2:
                errors['author'] = "Author name must be at least two characters."
            elif not name_pattern.match(postData['name']):
                errors['author'] = "Enter a valid author name."
        if postData['review'] and not postData['rating']:
            errors['review'] = "Rating is required when posting a review."
        return errors


class Author(models.Model):
    name = models.CharField(max_length=255)
    objects = FormManager()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

class Book(models.Model):
    title = models.CharField(max_length=255)
    desc = models.TextField()
    authors = models.ManyToManyField(Author, related_name="books_authored")
    objects = FormManager()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

class Review(models.Model):
    review = models.TextField()
    rating = models.IntegerField()
    book_reviewed = models.ForeignKey(Book,related_name="reviews")
    reviewer = models.ForeignKey(User,related_name="book_reviews")
    objects = FormManager()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
