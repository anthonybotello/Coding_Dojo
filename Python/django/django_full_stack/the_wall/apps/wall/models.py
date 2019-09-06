from django.db import models
from apps.login.models import User

# Create your models here.
class Post(models.Model):
    text = models.TextField()
    poster = models.ForeignKey(User,related_name="posts")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

class Comment(models.Model):
    text = models.TextField()
    message = models.ForeignKey(Post,related_name="comments")
    poster = models.ForeignKey(User,related_name="comments")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
