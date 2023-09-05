import React from 'react';
import {Button, Modal} from "react-bootstrap";
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import Timetable from "./Timetable";

const TimetableModal = ({route, stop, show, setShow}) => {
  const {data: timetable} = useFetch(baseUrl + "/api/TimeTables/byRoteAndStop?routeId=" + route.id + "&stopId=" + stop.id)

  return (
    <>
      {
        timetable &&
        <Modal show={show}>
          <Modal.Header>
            <Modal.Title>{route.transportType} №{route.number} - {stop.name}</Modal.Title>
          </Modal.Header>

          <Modal.Body>
            <Timetable timetable={timetable}/>
          </Modal.Body>

          <Modal.Footer>
            <Button variant="secondary" onClick={() => setShow(false)}>Закрыть</Button>
          </Modal.Footer>
        </Modal>
      }
    </>
  );
};

export default TimetableModal;