from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.index,name="home"),
    url(r'^add_course$',views.add_course,name="add"),
    url(r'^destroy$',views.destroy,name="delete"),
    url(r'^destroy/(?P<course_id>\d+)$',views.confirm,name="confirm"),
    url(r'^course/(?P<course_id>\d+)/comments$',views.comments,name="comments"),
    url(r'^add_comment$',views.add_comment,name="add_comment")
]