import React, {useEffect, useState} from 'react';
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import {Button, Col, Container, Form} from "react-bootstrap";
import RouteCard from "../components/RouteCard";

function sliceIntoChunks(arr, chunkSize) {
  const res = [];
  for (let i = 0; i < arr.length; i += chunkSize) {
    const chunk = arr.slice(i, i + chunkSize);
    res.push(chunk);
  }
  return res;
}

const Routes = () => {
  const {data: routes} = useFetch(baseUrl + "/api/routes")
  const {data: types} = useFetch(baseUrl + "/api/transportTypes")

  const [numberFilter, setNumberFilter] = useState("");
  const [nameFilter, setNameFilter] = useState("");
  const [transportFilter, setTransportFilter] = useState("Автобус");

  return (
    <>
      <Container className={"mt-3"}>
        <Form>
          <Form.Group className={"mb-3"}>
            <Form.Label>Тип транспорта</Form.Label>
            <Form.Select as="select" onChange={(e) => setTransportFilter(e.target.value)}>
              {
                types &&
                types?.map(t => <option value={t.name}>{t.name}</option>)
              }
            </Form.Select>
          </Form.Group>

          <Form.Group className={"mb-3"}>
            <Form.Label>Номер маршрута</Form.Label>
            <Form.Control
              type="search"
              placeholder="Номер"
              className="me-2"
              aria-label="Number"
              onChange={(e) => setNumberFilter(e.target.value)}
            />
          </Form.Group>

          <Form.Group className={"mb-3"}>
            <Form.Label>Название маршрута</Form.Label>
            <Form.Control
              type="search"
              placeholder="Название"
              className="me-2"
              aria-label="Name"
              onChange={(e) => setNameFilter(e.target.value)}
            />
          </Form.Group>
        </Form>
      </Container>
      <Container className={"d-flex flex-wrap justify-content-around"}>
        {
          routes &&
          routes?.sort((a, b) => a.number.match(/\d+/) - b.number.match(/\d+/))
            .filter(r => numberFilter.length == 0 ? true : r.number.toLowerCase().includes(numberFilter.toLowerCase()))
            .filter(r => nameFilter.length == 0 ? true : r.name.toLowerCase().includes(nameFilter.toLowerCase()))
            .filter(r => transportFilter.length == 0 ? true : r.transportType === transportFilter)
            .map(route => <Col sm={4} key={route.id}><RouteCard route={route} /></Col>)
        }
      </Container>
    </>
  );
};

export default Routes;