from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.wall),
    url(r'^make_post$',views.make_post),
    url(r'^post_comment$',views.post_comment),
    url(r'^delete_post$',views.delete_post)
]