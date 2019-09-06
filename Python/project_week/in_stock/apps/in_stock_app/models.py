from django.db import models

# Create your models here.
class Stock(models.Model):
    symbol = models.CharField(max_length=45)
    company_name = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)