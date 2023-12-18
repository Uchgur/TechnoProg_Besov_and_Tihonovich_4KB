import { feederCreationDTO } from "../feeders/feeder.model";

export function ConvertFeederToFormData(feeder: feederCreationDTO) {
  const formData = new FormData();

  formData.append("type", feeder.type);

  formData.append("foodWeight", feeder.foodWeight.toString());

  if (feeder.tag !== null) {
    formData.append("tag", feeder.tag);
  }

  formData.append("foodAtATime", feeder.foodAtATime.toString());

  formData.append("startTime", feeder.startTime!.toISOString());

  formData.append("endTime", feeder.endTime!.toISOString());

  formData.append("timesCatShouldEat", feeder.timesCatShouldEat.toString());

  formData.append("interval", formatInterval(feeder));

  formData.append("feedPresence", String(feeder.feedPresence));

  return formData;
}

function formatInterval(feeder: feederCreationDTO) {
  feeder.interval =
    (feeder.endTime!.getTime() - feeder.startTime!.getTime()) /
    feeder.timesCatShouldEat;
  let timeInterval = new Date(feeder.interval);

  return timeInterval.toISOString();
}
