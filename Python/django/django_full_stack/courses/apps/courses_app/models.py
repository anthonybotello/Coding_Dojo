from django.db import models
import re

# Create your models here.
class CourseManager(models.Manager):
    def course_validator(self,postData):
        errors={}
        course_pattern = re.compile(r'[A-Za-z0-9 ,()/.#&]+$')
        if len(postData['name']) < 6:
            errors['name'] = "Course name must be more than 5 characters."
        elif not course_pattern.match(postData['name']):
            errors['name'] = "Enter a valid course name."
        
        if len(postData['description']) < 16:
            errors['description'] = "Course description must be more than 15 characters."
        return errors

    def comment_validator(self,postData):
        errors={}
        if not postData['comment']:
            errors['comment'] = "Comment cannot be blank."
        return errors

class Course(models.Model):
    name = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = CourseManager()

class Description(models.Model):
    description = models.TextField()
    course = models.OneToOneField(Course,related_name="description")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = CourseManager()

class Comment(models.Model):
    comment = models.TextField()
    course = models.ForeignKey(Course,related_name="comments")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = CourseManager()