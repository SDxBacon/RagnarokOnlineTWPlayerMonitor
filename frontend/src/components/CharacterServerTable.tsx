import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { css } from "@emotion/react";

import { ragnarok } from "../../wailsjs/go/models";

interface CharacterServerTableProps {
  data: ragnarok.CharacterServerInfo[];
}

const CharacterServerTable = (props: CharacterServerTableProps) => {
  const { data } = props;

  return (
    <Table className="text-left">
      <TableHeader className="bg-chart-4">
        <TableRow>
          <TableHead>Server</TableHead>
          <TableHead>Address</TableHead>
          <TableHead>Players</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow className="hover:bg-primary">
          <TableCell className="font-medium">Lorem</TableCell>
          <TableCell>www.example.com:1234</TableCell>
          <TableCell>1000</TableCell>
        </TableRow>
        <TableRow>
          <TableCell className="font-medium">Lorem</TableCell>
          <TableCell>www.example.com:1234</TableCell>
          <TableCell>1000</TableCell>
        </TableRow>
        {data.map((item, index) => (
          <TableRow key={index}>
            <TableCell className="font-medium">{item.Name}</TableCell>
            <TableCell>{item.Url}</TableCell>
            <TableCell>{item.Players}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default CharacterServerTable;
