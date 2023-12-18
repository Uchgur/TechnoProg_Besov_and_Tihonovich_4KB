import { ErrorMessage, Field } from "formik";

export default function TextField(props: textFieldProps) {
  return (
    <div className="mb-3">
      <label htmlFor={props.field}>{props.displayName}</label>
      <Field
        name={props.field}
        id={props.field}
        className="form-control"
        type={props.type}
      />
      <ErrorMessage name={props.field}>
        {(msg) => <div className="text-danger">{msg}</div>}
      </ErrorMessage>
    </div>
  );
}

interface textFieldProps {
  field: string;
  displayName: string;
  type: string;
  disabled: boolean;
}

TextField.defaultProps = {
  type: "text",
  disabled: false,
};
