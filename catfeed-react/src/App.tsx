import { useEffect, useState } from "react";
import "./App.css";
import Menu from "./Menu";
import Authorized from "./auth/Authorize";
import { claim } from "./auth/auth.model";
import FeederIndex from "./feeders/feederIndex";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import { getClaims } from "./auth/HandleJWT";
import AuthenticationContext from "./auth/AuthentificationContext";
import Register from "./auth/register";
import Login from "./auth/login";
import configureInterceptor from "./utils/HttpInterceptors";
import AllFeedersIndex from "./feeders/allFeedersIndex";
import FeederCreate from "./feeders/feederCreate";
import FeederEdit from "./feeders/feederEdit";
import LogIndex from "./logs/logIndex";
import AllLogsIndex from "./logs/allLogsIndex";
import UserIndex from "./auth/userIndex";

configureInterceptor();

function App() {
  const [claims, setClaims] = useState<claim[]>([]);

  useEffect(() => {
    setClaims(getClaims());
  }, []);

  function isAdmin() {
    return (
      claims.findIndex(
        (claim) => claim.name === "role" && claim.value === "admin"
      ) > -1
    );
  }

  return (
    <>
      <BrowserRouter>
        <Switch>
          <AuthenticationContext.Provider value={{ claims, update: setClaims }}>
            <Menu />
            <div className="container">
              {isAdmin() ? (
                <Route exact path="/feeders/all">
                  <AllFeedersIndex />
                </Route>
              ) : (
                <Route exact path="/feeders/all">
                  <>You are not allowed to see whis page</>
                </Route>
              )}

              <Route exact path="/feeders">
                <FeederIndex />
              </Route>

              <Route exact path="/logs">
                <LogIndex />
              </Route>

              {isAdmin() ? (
                <Route exact path="/logs/all">
                  <AllLogsIndex />
                </Route>
              ) : (
                <Route exact path="/logs/all">
                  <>You are not allowed to see whis page</>
                </Route>
              )}

              {isAdmin() ? (
                <Route exact path="/accounts/listUsers">
                  <UserIndex />
                </Route>
              ) : (
                <Route exact path="/accounts/listUsers">
                  <>You are not allowed to see whis page</>
                </Route>
              )}

              <Route path={"/feeders/create"}>
                <FeederCreate />
              </Route>
              <Route path={"/feeders/edit/:id"}>
                <FeederEdit />
              </Route>

              <Route path="/accounts/create">
                <Register />
              </Route>
              <Authorized
                authorized={<Redirect from="/" to="/feeders" />}
                notAuthorized={<Redirect from="/" to="/accounts/login" />}
              />
              <Route path="/accounts/login">
                <Login />
              </Route>
            </div>
          </AuthenticationContext.Provider>
        </Switch>
      </BrowserRouter>
    </>
  );
}

export default App;
