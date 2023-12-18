import axios from 'axios';
import { authenticationResponse, userCredentials } from './auth.model';
import AuthForm from './authForm';
import { useContext } from 'react';
import { getClaims, saveToken } from './HandleJWT';
import AuthenticationContext from './AuthentificationContext';
import { useHistory } from 'react-router-dom';

export default function Login(){
    const {update} = useContext(AuthenticationContext);
    const history = useHistory();

    async function login(credentials: userCredentials){
            const response = await axios
            .post<authenticationResponse>(`https://localhost:7282/api/accounts/login`, credentials);
            saveToken(response.data);
            update(getClaims());
            history.push('/feeders');
    }

    return (
        <>
            <h3>Login</h3>
            <AuthForm model={{email: '', password: ''}}
             onSubmit={async values => await login(values)}
            />
        </>
    )
}