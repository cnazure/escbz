var map = new BMap.Map('map_container', { defaultCursor: 'default' });
map.centerAndZoom(new BMap.Point(121.506303, 31.245638), 11);

var TILE_SIZE = 256;
map.enableScrollWheelZoom(true);
map.addEventListener('click', function(e){
    var info = new BMap.InfoWindow('', {width: 260});
    var projection = this.getMapType().getProjection();
  
    var lngLat = e.point;  
    var lngLatStr = "经纬度：" + lngLat.lng + ", " + lngLat.lat;
  

    info.setContent(lngLatStr);
    map.openInfoWindow(info, lngLat);
});
