import { Navigate } from 'react-router-dom';

export const PrivateRoute = ({ children, redirectTo = "/"}) => {

    const isAutheticated = localStorage.getItem("token") !== null;

    return isAutheticated ? children : <Navigate to = {redirectTo}/>
    

}