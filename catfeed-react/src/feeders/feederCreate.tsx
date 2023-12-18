import axios from "axios";
import { ConvertFeederToFormData } from "../utils/formDataUtil";
import { feederCreationDTO } from "./feeder.model";
import FeederForm from "./feederForm";
import { useHistory } from "react-router-dom";

export default function FeederCreate() {
  const history = useHistory();

  async function create(feeder: feederCreationDTO) {
    const formData = ConvertFeederToFormData(feeder);

    await axios({
      method: "post",
      url: "https://localhost:7282/api/feeders",
      data: formData,
      headers: { "Content-Type": "multipart/form-data" },
    });

    history.push("/feeders");
  }

  return (
    <>
      <h3>Create Feeder</h3>
      <FeederForm
        model={{
          type: "",
          foodWeight: 0,
          tag: "",
          foodAtATime: 0,
          startTime: undefined,
          endTime: undefined,
          interval: 0,
          timesCatShouldEat: 0,
          feedPresence: false,
        }}
        onSubmit={async (values) => await create(values)}
        onEdit={false}
      />
    </>
  );
}
