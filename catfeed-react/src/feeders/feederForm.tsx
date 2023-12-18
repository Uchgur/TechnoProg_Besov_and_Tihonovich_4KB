import { Field, Form, Formik, FormikHelpers } from "formik";
import { feederCreationDTO } from "./feeder.model";
import { Link } from "react-router-dom";
import TextField from "../utils/TextField";
import Button from "../utils/Button";
import * as Yup from "yup";
import DateField from "../utils/DateField";

export default function FeederForm(props: feederFormProps) {
  return (
    <Formik
      initialValues={props.model}
      onSubmit={props.onSubmit}
      validationSchema={Yup.object({
        foodWeight: Yup.number()
          .required("This field is required!")
          .min(0, "Min weight is 0 gramms")
          .max(2000, "Max weight is 2000 gramms"),
        tag: Yup.string().max(50, "Max length is 50 characters!"),
        foodAtATime: Yup.number()
          .required("This field is required!")
          .min(0, "Min weight is 0 gramms")
          .max(500, "Max weight is 500 gramms"),
      })}
    >
      {(formikProps) => (
        <Form>
          <label>Feeder Type</label>
          <br />
          <Field as="select" name="type" className="form-select" disabled={props.onEdit ? true : false}>
            <option value="Feeder With Dispenser" selected>
              Feeder With Dispenser
            </option>
            <option value="Feeder With Rotor">Feeder With Rotor</option>
          </Field>
          <TextField
            field="foodWeight"
            displayName="Food Weight"
            type="number"
          />
          {
            (formikProps.values.feedPresence = Boolean(
              formikProps.values.foodWeight
            ))
          }

          <TextField field="tag" displayName="Tag" />
          <TextField
            field="foodAtATime"
            displayName="Food At A Time"
            type="number"
          />
          <DateField displayName="Start Time" field="startTime" />
          <DateField displayName="End Time" field="endTime" />
          <TextField
            field="timesCatShouldEat"
            displayName="Times Cat Should Eat"
            type="number"
          />
          <div className="hidden-field">
            {
              (formikProps.values.interval =
                (formikProps.values.endTime?.getTime()! -
                  formikProps.values.startTime?.getTime()!) /
                formikProps.values.timesCatShouldEat)
            }
          </div>

          <Button
            className="btn btn-primary"
            disabled={formikProps.isSubmitting}
            type="submit"
          >
            Save Changes
          </Button>
          <Link className="btn btn-secondary" to="/feeders">
            Cancel
          </Link>
        </Form>
      )}
    </Formik>
  );
}

interface feederFormProps {
  model: feederCreationDTO;
  onEdit: boolean;
  onSubmit(
    values: feederCreationDTO,
    action: FormikHelpers<feederCreationDTO>
  ): void;
}
