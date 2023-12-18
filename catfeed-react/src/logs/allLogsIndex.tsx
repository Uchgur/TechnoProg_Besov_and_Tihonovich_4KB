import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { logDTO } from "./log.model";
import axios from "axios";
import GenericList from "../utils/GenericList";

export default function AllLogsIndex() {
  const [logs, setLogs] = useState<logDTO[]>([]);
  const location = useLocation();

  useEffect(() => {
    axios.get("https://localhost:7282/api/logs/all").then((response) => {
      setLogs(response.data);
    });
  }, [location]);

  return (
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
            <td>User ID</td>
          </thead>
          <tbody>
            {logs?.map((log) => (
              <tr key={log.id}>
                <td></td>
                <td>{log.logTime.toString()}</td>
                <td></td>
                <td>{log.message}</td>
                <td></td>
                <td>{log.feederUserId}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </GenericList>
    </>
  );
}
