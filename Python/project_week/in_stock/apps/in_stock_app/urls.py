from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$',views.index,name="home"),
    url(r'^dashboard$',views.dashboard,name="dashboard"),
    url(r'^browse$',views.browse,name="browse"),
    url(r'^browse/(?P<symbol>\w+)$',views.stock_info,name="info"),
    url(r'^portfolio$',views.portfolio,name="portfolio")
]