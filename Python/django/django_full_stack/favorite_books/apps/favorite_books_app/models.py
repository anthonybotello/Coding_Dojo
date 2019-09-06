from django.db import models
from apps.login.models import User

# Create your models here.
class BookManager(models.Manager):
    def book_validator(self,postData):
        errors = {}
        if not postData['title']:
            errors['title'] = "Title is required."
        if len(postData['desc']) < 5:
            errors['desc'] = "Description must be at least 5 characters"
        return errors


class Book(models.Model):
    title = models.CharField(max_length=255)
    desc = models.TextField()
    uploaded_by = models.ForeignKey(User,related_name="books_uploaded")
    users_who_like = models.ManyToManyField(User,related_name="liked_books")
    objects = BookManager()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)