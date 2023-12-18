import { useContext } from "react";
import { Link, NavLink, Route, Switch } from "react-router-dom";
import Authorized from "./auth/Authorize";
import AuthenticationContext from "./auth/AuthentificationContext";
import Button from "./utils/Button";
import { logout } from "./auth/HandleJWT";

export default function Menu() {
  const { update, claims } = useContext(AuthenticationContext);

  function getUserEmail(): string {
    return claims.filter((x) => x.name === "email")[0]?.value;
  }

  return (
    <Switch>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <NavLink className="navbar-brand" to="/feeders">
            My Feeders
          </NavLink>
          <div className="collapse navbar-collapse" style={{ display: "flex" }}>
            <NavLink
              className="navbar-nav"
              to="/logs"
              style={{ margin: "0px 15px 0px 15px" }}
            >
              Logs
            </NavLink>
            <Authorized
              role="admin"
              authorized={
                <>
                  <NavLink
                    className="navbar-nav"
                    to="/feeders/all"
                    style={{ margin: "0px 15px 0px 15px" }}
                  >
                    All Feeders
                  </NavLink>
                  <NavLink
                    className="navbar-nav"
                    to="/logs/all"
                    style={{ margin: "0px 15px 0px 15px" }}
                  >
                    All Logs
                  </NavLink>
                  <NavLink
                    className="navbar-nav"
                    to="/accounts/listUsers"
                    style={{ margin: "0px 15px 0px 15px" }}
                  >
                    Users To Confirm
                  </NavLink>
                </>
              }
            />
          </div>
          <ul className="navbar-nav me-auto mb-2 mb-lg-0">
            <div className="d-flex">
              <Authorized
                authorized={
                  <>
                    <span className="nav-link">Hello, {getUserEmail()}</span>
                    <Button
                      onClick={() => {
                        logout();
                        update([]);
                      }}
                      className="nav-link btn btn-link"
                    >
                      Log Out
                    </Button>
                  </>
                }
                notAuthorized={
                  <>
                    <Link
                      to="/accounts/create"
                      className="nav-link btn btn-link"
                    >
                      Register
                    </Link>
                    <Link
                      to="/accounts/login"
                      className="nav-link btn btn-link"
                    >
                      Login
                    </Link>
                  </>
                }
              />
            </div>
          </ul>
        </div>
      </nav>
    </Switch>
  );
}
