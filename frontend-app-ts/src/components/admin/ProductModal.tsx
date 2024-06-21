import React, { useEffect, useState } from "react";
import { Button, Modal, ModalHeader, ModalBody } from "reactstrap";
import AddEditForm from "./Forms/FormAddEdit";

export default  function ModalForm(props :any) {
  const [modal, setModal] = useState(false);
  useEffect(()=>{
    // console.log(props.detail.id)
  },[])
  const toggle = () => {
    setModal(!modal);
  };

  const closeBtn = (
    <button className="close" onClick={toggle} style={{marginLeft :"330px",border :"0px solid  #ccc", backgroundColor:"#fff",fontSize:"20px"}}>
      &times;
    </button>
  );
  const label = props.buttonLabel;

  let button
  let title = "";

  if (label === "Edit") {
    button = (
      <Button
        color="warning"
        onClick={toggle}
        style={{ float: "left", marginRight: "10px" }}
      >
        {label}
      </Button>
    );
    title = "Edit Item";
  } else {
    button = (
      <Button
        color="#ffff"
    
        onClick={toggle}
        style={{ float: "left", marginRight: "10px", border:"1px solid #000" }}
      >
        {label}
      </Button>
    );
    title = "Sửa sản phẩm";
  }

  return (
    <div>
      {button}
      <Modal
        isOpen={modal}
        toggle={toggle}
        className={props.className}
        backdrop={"static"}
        keyboard={false}
      >
        <ModalHeader toggle={toggle} close={closeBtn}>
          {title}
        </ModalHeader>
        <ModalBody>
          <AddEditForm
            detail ={props.detail}
            // updateState = {props.updateState}
          />
        </ModalBody>
      </Modal>
    </div>
  );
}


