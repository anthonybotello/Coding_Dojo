from django.conf.urls import url,include
from . import views


urlpatterns = [
    url(r'^$',include('apps.blog_app.urls')),
    url(r'^register$',views.register,name="register"),
    url(r'^login$',views.login,name="login"),
    url(r'^users/new$',views.register),
    url(r'^users$',views.users,name="users")
]