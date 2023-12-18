import { useContext, useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { logDTO } from "./log.model";
import AuthenticationContext from "../auth/AuthentificationContext";
import axios from "axios";
import GenericList from "../utils/GenericList";
import Authorized from "../auth/Authorize";

export default function LogIndex() {
  const [logs, setLogs] = useState<logDTO[]>([]);
  const location = useLocation();

  const { update, claims } = useContext(AuthenticationContext);

  function getUserEmail(): string {
    return claims.filter((x) => x.name === "email")[0]?.value;
  }

  useEffect(() => {
    axios.get("https://localhost:7282/api/logs").then((response) => {
      setLogs(response.data);
    });
  }, [location]);

  return (
    <>
      <Authorized
        authorized={
          <>
            <GenericList list={logs}>
              <table
                className="table table-striped"
                style={{ textAlign: "center", verticalAlign: "middle" }}
              >
                <thead>
                  <td></td>
                  <td>Date</td>
                  <td></td>
                  <td>Message</td>
                  <td></td>
                  <td>User Email</td>
                </thead>
                <tbody>
                  {logs?.map((log) => (
                    <tr key={log.id}>
                      <td></td>
                      <td>{log.logTime.toString()}</td>
                      <td></td>
                      <td>{log.message}</td>
                      <td></td>
                      <td>{getUserEmail()}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </GenericList>
          </>
        }
        notAuthorized={<h3>You are not allowed to see this page!</h3>}
      />
    </>
  );
}
