import { useContext, useEffect, useState } from "react";
import { feederDTO } from "./feeder.model";
import axios from "axios";
import { Link, useLocation } from "react-router-dom";
import GenericList from "../utils/GenericList";
import AuthenticationContext from "../auth/AuthentificationContext";
import Authorized from "../auth/Authorize";

export default function FeederIndex() {
  const [feeders, setFeeders] = useState<feederDTO[]>([]);
  const location = useLocation();

  const { update, claims } = useContext(AuthenticationContext);

  function getUserEmail(): string {
    return claims.filter((x) => x.name === "email")[0]?.value;
  }

  useEffect(() => {
    axios.get("https://localhost:7282/api/feeders").then((response) => {
      setFeeders(response.data);
    });
  }, [location]);

  return (
    <>
      <Authorized
        authorized={
          <>
            <Link to="/feeders/create" className="btn btn-primary">
              Create
            </Link>

            <GenericList list={feeders}>
              <table
                className="table table-striped"
                style={{ textAlign: "center", verticalAlign: "middle" }}
              >
                <thead>
                  <td></td>
                  <td>Type</td>
                  <td></td>
                  <td>Tag</td>
                  <td></td>
                  <td>Feed Presence</td>
                  <td></td>
                  <td>User Email</td>
                </thead>
                <tbody>
                  {feeders?.map((feeder) => (
                    <tr key={feeder.id}>
                      <td></td>
                      <td>{feeder.type}</td>
                      <td></td>
                      <td>{feeder.tag}</td>
                      <td></td>
                      <td>{feeder.feedPresence.toString()}</td>
                      <td></td>
                      <td>{getUserEmail()}</td>
                      <td>
                        <Link
                          className="btn btn-primary"
                          to={`/feeders/edit/${feeder.id}`}
                        >
                          Edit
                        </Link>
                      </td>
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
