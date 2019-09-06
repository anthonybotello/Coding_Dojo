from django.db import models
from datetime import datetime
# Create your models here.
class ShowManager(models.Manager):
    def validator(self,postData):
        errors = {}
        if len(postData['title']) < 2:
            if len(postData['title']) == 0:
                errors['title'] = "Title is required!"
            else:
                errors['title'] = "Title must be at least 2 characters!"
        if len(postData['network']) < 3:
            if len(postData['network']) == 0:
                errors['network'] = "Network is required!"
            else:
                errors['network'] = "Network must be at least 3 characters!"
        if datetime.strptime(postData['release_date'],'%Y-%m-%d') > datetime.today():
            errors['release_date'] = "Date cannot be in the future!"
        if 0 < len(postData['description']) < 10:
            errors['description'] = "If provided, description must be at least 10 characters!"
        return errors


class Show(models.Model):
    title = models.CharField(max_length=255)
    network = models.CharField(max_length=45)
    release_date = models.DateField()
    description = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = ShowManager()

    def __repr__(self):
        return f"<Show object: ({self.id}) {self.title}>"

