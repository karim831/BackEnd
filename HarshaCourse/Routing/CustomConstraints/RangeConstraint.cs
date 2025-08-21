namespace Routing.CustomConstraints;

public class RangeConstraint: IRouteConstraint{
    private readonly int _max;
    private readonly int _min;

    
    public RangeConstraint(int min,int max){
        _min = min;
        _max = max;
    }

    public bool Match(
        HttpContext? httpContext, IRouter? route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection
    ){
        if(values[routeKey] is not string tmp || !int.TryParse(tmp,out int routeValue))
            return false;
        
        return routeValue >= _min && routeValue <= _max; 
    }
     
}
