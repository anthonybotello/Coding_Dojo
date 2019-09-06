from django.shortcuts import render, redirect, reverse, HttpResponse
from .models import *
from django.contrib import messages

# Create your views here.
def index(request):
    context = {
        'courses': Course.objects.all()
    }
    return render(request,'courses_app/index.html',context)

def add_course(request):
    errors = Course.objects.course_validator(request.POST)
    if len(errors) > 0:
        print("ERRORS!!!!!")
        for key,value in errors.items():
            messages.error(request,value)
        return redirect(reverse('courses:home'))
    else:
        Course.objects.create(name=request.POST['name'])
        Description.objects.create(description=request.POST['description'],course=Course.objects.last())
    return redirect(reverse('courses:home'))

def confirm(request,course_id):
    context={
        'course': Course.objects.get(id=course_id)
    }
    return render(request,'courses_app/destroy.html',context)

def destroy(request):
    for comment in Comment.objects.filter(course__id=request.POST['course_id']):
        comment.delete()
    Description.objects.get(course__id=request.POST['course_id']).delete()
    Course.objects.get(id=request.POST['course_id']).delete()
    return redirect(reverse('courses:home'))

def comments(request,course_id):
    context = {
        'course': Course.objects.get(id=course_id)
    }
    return render(request,'courses_app/comments.html',context)

def add_comment(request):
    errors = Comment.objects.comment_validator(request.POST)
    print(request.POST['course_id'])
    course_id=int(request.POST['course_id'])
    course_id = int(request.POST['course_id'])
    if len(errors) > 0:
        for key,value in errors.items():
            messages.error(request,value)
        return redirect(reverse('courses:comments', kwargs={'course_id':course_id}))
    else:
        Comment.objects.create(
            comment=request.POST['comment'],
            course=Course.objects.get(id=course_id)
        )
    return redirect(reverse('courses:comments',kwargs={'course_id':course_id}))