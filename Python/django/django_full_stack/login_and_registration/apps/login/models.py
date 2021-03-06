from __future__ import unicode_literals
from django.db import models
import re
import bcrypt
from datetime import datetime, timedelta

# Create your models here.
class UserManager(models.Manager):
    def registration_validator(self,postData):
        errors = {}

        name_pattern = re.compile(r'^[A-Za-z- ]+$')
        if not postData['first_name']:
            errors['first_name'] = "First name is required."
        else:
            if len(postData['first_name']) < 2:
                errors['first_name'] = "First name must be at least two characters."
            elif not name_pattern.match(postData['first_name']):
                errors['first_name'] = "Enter a valid first name."
        
        if not postData['last_name']:
            errors['last_name'] = "Last name is required."
        else:
            if len(postData['last_name']) < 2:
                errors['last_name'] = "Last name must be at least two characters."
            elif not name_pattern.match(postData['last_name']):
                errors['last_name'] = "Enter a valid last name."

        if not postData['birthday']:
            errors['birthday'] = "Birthday is required."
        elif datetime.strptime(postData['birthday'],'%Y-%m-%d').date() > datetime.today().date():
            errors['birthday'] = "Birthday cannot be in the future."
        elif datetime.today().date() - datetime.strptime(postData['birthday'],'%Y-%m-%d').date() < timedelta(days=13*365.25):
            errors['birthday'] = "Must be at least 13 years old to register."

        email_pattern = re.compile(r'^[A-Za-z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not postData['email']:
            errors['email'] = "Email address is required."
        elif not email_pattern.match(postData['email']):
            errors['email'] = "Enter a valid email address."

        if not postData['password']:
            errors['password'] = "Password is required."
        elif len(postData['password']) < 8:
            errors['password'] = "Enter a valid password."
        if postData['password'] != postData['confirm_password']:
            errors['confirm_pw'] = "Passwords do not match."
        return errors

    def login_validator(self,postData):
        errors={}
        valid_email = True
        user_id = None
        email_pattern = re.compile(r'^[A-Za-z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not postData['email']:
            errors['login_email'] = "Email address is required."
        elif not email_pattern.match(postData['email']):
            errors['login_email'] = "Enter a valid email address."
            valid_email = False
        else:
            user = User.objects.filter(email__iexact=postData['email'])
            if len(user) == 0:
                errors['login_email'] = "This email is not registered."
            else:
                user_id = user[0].id

        if len(postData['password']) < 8:
            errors['login_password'] = "Enter a valid password."
        elif len(user) > 0:
            if not bcrypt.checkpw(postData['password'].encode(),user[0].password.encode()):
                errors['login_password'] = "Invalid email and password combination."
        return errors,user_id
        

class User(models.Model):
    first_name = models.CharField(max_length=45)
    last_name = models.CharField(max_length=45)
    birthday = models.DateTimeField()
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()

    def __repr__(self):
        return f"<User object: ({self.id}) {self.first_name} {self.last_name}>"
