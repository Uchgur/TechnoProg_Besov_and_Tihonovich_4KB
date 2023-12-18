import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { feederCreationDTO, feederDTO } from "./feeder.model";
import axios from "axios";
import { ConvertFeederToFormData } from "../utils/formDataUtil";
import FeederForm from "./feederForm";
import Button from "../utils/Button";

export default function FeederEdit() {
  const { id }: any = useParams();
  const [feeder, setFeeder] = useState<feederCreationDTO>();
  const history = useHistory();

  function transform(feeder: feederDTO): feederCreationDTO {
    return {
      type: feeder.type,
      foodWeight: feeder.foodWeight,
      tag: feeder.tag,
      foodAtATime: feeder.foodAtATime,
      startTime: new Date(),
      endTime: new Date(),
      timesCatShouldEat: feeder.timesCatShouldEat,
      interval: 0,
      feedPresence: feeder.feedPresence,
    };
  }

  useEffect(() => {
    axios.get(`https://localhost:7282/api/feeders/${id}`).then((response) => {
      setFeeder(transform(response.data));
    });
  }, [id]);

  async function edit(feederToEdit: feederCreationDTO) {
    const formData = ConvertFeederToFormData(feederToEdit);
    await axios({
      method: "put",
      url: `https://localhost:7282/api/feeders/${id}`,
      data: formData,
      headers: { "Content-Type": "multipart/form-data" },
    });

    history.push("/feeders");
  }

  async function deleteFeeder() {
    await axios.delete(`https://localhost:7282/api/feeders/${id}`);
    history.push("/feeders");
  }

  return (
    <>
      <h3>Edit Feeder</h3>
      {feeder ? (
        <>
          <FeederForm
            model={feeder!}
            onSubmit={async (value) => await edit(value)}
            onEdit={true}
          />
          <Button className="btn btn-danger" onClick={deleteFeeder}>
            Delete
          </Button>
        </>
      ) : (
        <p>Loading....</p>
      )}
    </>
  );
}
