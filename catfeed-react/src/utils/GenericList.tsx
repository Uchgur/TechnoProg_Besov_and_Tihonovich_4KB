import { ReactElement } from "react";

export default function GenericList(props: genericListProps) {
  if (!props.list) {
    if (props.loadingUI) {
      return props.loadingUI;
    }
    return <h3>Loading...</h3>;
  } else if (props.list.length === 0) {
    if (props.emptyListUI) {
      return props.emptyListUI;
    }
    return (
      <>
        <td></td>
        There are no elements to display
      </>
    );
  } else {
    return props.children;
  }
}

interface genericListProps {
  list: any;
  loadingUI?: ReactElement;
  emptyListUI?: ReactElement;
  children: ReactElement;
}
