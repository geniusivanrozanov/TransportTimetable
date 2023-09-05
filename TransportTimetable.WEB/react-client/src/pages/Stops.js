import React, {useState} from 'react';
import {Container, Form} from "react-bootstrap";
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import StopCard from "../components/StopCard";
import {useLocalStorage} from "../hooks/useLocalStorage";

function Stops() {
  const {data: stops} = useFetch(baseUrl + "/api/stops")

  const [nameFilter, setNameFilter] = useState("");
  const [saved, setSaved] = useState(false);

  const localStorage = useLocalStorage("stops")

  return (
    <>
      <Container className={"mt-3"}>
        <Form>
          <Form.Group className={"mb-3"}>
            <Form.Label>Название остановки</Form.Label>
            <Form.Control
              type="search"
              placeholder="Название"
              className="me-2"
              aria-label="Name"
              onChange={(e) => setNameFilter(e.target.value)}
            />
          </Form.Group>
          <Form.Group className={"mb-3"}>
            <Form.Label>Только избранное</Form.Label>
            <Form.Check
              type="checkbox"
              defaultChecked={saved}
              className="me-2"
              aria-label="Name"
              onChange={(e) => setSaved(e.target.checked)}
            />
          </Form.Group>
        </Form>
      </Container>
      <Container className={"mt-3"}>
        {stops && stops.sort((a, b) => a.name > b.name ? 1 : -1)
          .filter(s => nameFilter.length == 0 ? true : s.name.toLowerCase().includes(nameFilter.toLowerCase()))
          .filter(s => !saved ? true : localStorage.Exsists(s.id))
          .map(stop => <StopCard stop={stop}/>)}
      </Container>
    </>
  );
}

export default Stops;