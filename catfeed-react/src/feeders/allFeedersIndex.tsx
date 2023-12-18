import axios from "axios";
import { useEffect, useState } from "react";
import GenericList from "../utils/GenericList";
import { feederDTO } from "./feeder.model";

export default function AllFeedersIndex() {
  const [feeders, setFeeders] = useState<feederDTO[]>([]);

  useEffect(() => {
    axios.get("https://localhost:7282/api/feeders/all").then((response) => {
      setFeeders(response.data);
    });
  }, []);

  return (
        <GenericList list={feeders}>
          <table className="table table-striped" style={{textAlign: "center", verticalAlign: "middle"}}>
            <thead>
              <td></td>
              <td>Type</td>
              <td></td>
              <td>Tag</td>
              <td></td>
              <td>Feed Presence</td>
              <td></td>
              <td>Feeder User ID</td>
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
                  <td>{feeder.feederUserId}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </GenericList>
  );
}
